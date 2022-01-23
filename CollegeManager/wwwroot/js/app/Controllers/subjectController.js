//subjects controller
app.controller('subjectController', function ($scope, baseService, enrollmentService) {


    $scope.objData = [];
    $scope.msgError = "";
    $scope.msgSuccess = "";
    $scope.objModel = {};
    $scope.SubjectName = "";

    $scope.teachersList = [];
    $scope.coursesList = [];
    $scope.enrollmentsList = [];
    $scope.studentsList = [];

    baseService.SetAlias('subject');



    $scope.GetCourseList = function () {
        baseService.GetByModel('course').then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.coursesList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };


    $scope.GetTeacherList = function () {
        baseService.GetByModel('teacher').then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.teachersList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.GetStudentsList = function () {
        baseService.GetByModel('student').then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.studentsList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.GetList = function () {
        baseService.GetList().then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.objData = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    var setDefaultModel = function () {
        $scope.objModel = {
            Id: "",
            Name: "",
            CourseId: "",
            Course: "",
            TeacherId: "",
            Teacher: "",
            StudentId: "",
            SubjectId: "",
        };
    };

    $scope.GetList();
    $scope.GetCourseList();
    $scope.GetTeacherList();
    $scope.GetStudentsList();
    setDefaultModel();

    $scope.Cancel = function () {
        setDefaultModel();
    };

    $scope.Save = function () {
        var objForm = {
            Name: $scope.objModel.Name,
            Course: $scope.objModel.Course,
            CourseId: $scope.objModel.CourseId,
            Teacher: $scope.objModel.Teacher,
            TeacherId: $scope.objModel.TeacherId
        };

        baseService.Save(objForm).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.GetList();
                setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });

    };

    $scope.editId = function (model) {
        $scope.objModel = {
            Id: model.Id,
            Name: model.Name,
            Course: model.Course.Name,
            CourseId: model.CourseId,
            Teacher: model.Teacher.Name,
            TeacherId: model.TeacherId
        };
    };

    $scope.edit = function () {
        var objForm = {
            Id: $scope.objModel.Id,
            Name: $scope.objModel.Name,
            CourseId: $scope.objModel.CourseId,
            TeacherId: $scope.objModel.TeacherId,
        };

        baseService.Edit(objForm).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.GetList();
                setDefaultModel();
                $scope.msgSuccess = "Edit complete!"
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.deleteId = function (model) {
        $scope.objModel = {
            Id: model.Id,
            Name: model.Name
        };
    };

    $scope.delete = function () {
        baseService.Delete($scope.objModel.Id).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.GetList();
                $scope.setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    //STUDENTS GRADES AREA
    $scope.showStudents = function (model) {
        $scope.selectedSubject = true;
        $scope.SubjectName = model.Name;
        $scope.SubjectId = model.Id;
        enrollmentService.getEnrollmentBySubjectId(model.Id).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.enrollmentsList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.Close = function () {
        $scope.selectedSubject = false;
        setDefaultModel();
    };

    $scope.editGradeId = function (model) {
        $scope.objModel = {
            EnrollmentId : model.EnrollmentId,
            StudentId: model.StudentId,
            StudentName: model.Student.Name,
            SubjectId: model.SubjectId,
            Grade: model.Grade,   
        };
    };

    $scope.editGrade = function () {
        var objForm = {
            EnrollmentId: $scope.objModel.EnrollmentId,
            StudentId: $scope.objModel.StudentId,
            StudentName: $scope.objModel.StudentName,
            SubjectId: $scope.objModel.SubjectId,
            Grade: $scope.objModel.Grade,
        };

        var obj = {
            Id: $scope.objModel.SubjectId,
            Name: $scope.SubjectName
        };


        baseService.SetAlias('enrollment');

        baseService.Edit(objForm).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                setDefaultModel();
                $scope.showStudents(obj);
                baseService.SetAlias('subject');
                $scope.msgSuccess = "Edit complete!"
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.addStudent = function () {
        var objForm = {
            StudentId: $scope.objModel.StudentId,
            SubjectId: $scope.SubjectId,
        };

        var obj = {
            Id: $scope.SubjectId,
            Name: $scope.SubjectName
        };

        baseService.SetAlias('enrollment');
        baseService.Save(objForm).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                baseService.SetAlias('subject');
                $scope.showStudents(obj);
                setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });

    };

    $scope.deleteEnrollmentId = function (model) {
        $scope.objModel = {
            EnrollmentId: model.EnrollmentId,
            SubjectId: model.SubjectId,
            StudentName: model.Student.Name
        };
    };

    $scope.deleteEnrollment = function () {

        var obj = {
            Id: $scope.objModel.SubjectId,
            Name: $scope.SubjectName
        };


        baseService.SetAlias('enrollment');
        baseService.Delete($scope.objModel.EnrollmentId).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.showStudents(obj);
                baseService.SetAlias('subject');
                $scope.setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

});