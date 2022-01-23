//subjects controller
app.controller('courseController', function ($scope, baseService, enrollmentService) {


    $scope.objData = [];
    $scope.msgError = "";
    $scope.objModel = {};

    $scope.subjectsList = [];
    $scope.studentsList = [];
    $scope.enrollmentsList = [];
    $scope.studentsList = [];

    baseService.SetAlias('course');



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

    $scope.GetEnrollmentsList = function () {
        baseService.GetByModel('enrollment').then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.enrollmentsList = results.data;
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
            Teacher: ""
        };
    };

    $scope.GetList();
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

    $scope.showStudents = function (model) {
        enrollmentService.getEnrollmentBySubjectId(model.Id).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.studentsList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

   

});