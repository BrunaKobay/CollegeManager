//students controller
app.controller('studentController', function ($scope, baseService) {


    $scope.objData = [];
    $scope.msgError = "";
    $scope.objModel = {};


    baseService.SetAlias('student');

    $scope.GetList = function () {
        baseService.GetList().then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
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
            Birthday: "",
            RegistrationId: "",
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
            Birthday: $scope.objModel.Birthday,
            RegistrationId: $scope.objModel.RegistrationId,
        };

        baseService.Save(objForm).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
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
            Birthday: model.Birthday,
            RegistrationId: model.RegistrationId,
        };
    };

    $scope.edit = function () {

        var objForm = {
            Id: $scope.objModel.Id,
            Name: $scope.objModel.Name,
            Birthday: $scope.objModel.Birthday,
            RegistrationId: $scope.objModel.RegistrationId,
        };

        baseService.Edit(objForm).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
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

    $scope.delete= function () {
        baseService.Delete($scope.objModel.Id).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.GetList();
                setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    


    //loadStudents();

    //function loadStudents() {
    //    studentService.getAllStudents().then(function (results) {
    //        if (results.data.error_message) {
    //            $scope.msgError = results.data.error_message;
    //        } else {
    //            $scope.Students = results.data;
    //        }
    //    }, function (error) {
    //        $scope.msgError = 'An error happened while getting all students' + error;
    //    });
    //};


    //$scope.Save = function () {
    //    //$scope.showForm = false;
    //    var student = {
    //        Name: $scope.Name,
    //        Birthday: $scope.Birthday,
    //        RegistrationId: $scope.RegistrationId,
    //        CourseId: $scope.CourseId
    //    };

    //    studentService.addStudent(student).then(function (results) {
    //        if (results.data.error_message) {
    //            $scope.msgError = results.data.error_message;
    //        } else {
    //            loadStudents();
    //            $scope.setDefaultModel();
    //        }
    //    }, function (error) {
    //        $scope.msgError = error;
    //    });

    //};

    //$scope.editStudentId = function (student) {
    //    $scope.Id = student.Id;
    //    $scope.Name = student.Name;
    //    $scope.Birthday = student.Birthday;
    //    $scope.RegistrationId = student.RegistrationId;
    //    $scope.CourseId = student.CourseId;
    //};

    //$scope.editStudent = function () {
    //    var student = {
    //        Id: $scope.Id,
    //        Name: $scope.Name,
    //        Birthday: $scope.Birthday,
    //        RegistrationId: $scope.RegistrationId,
    //        CourseId: $scope.CourseId
    //    };

    //    studentService.editStudent(student).then(function (results) {
    //        if (results.data.error_message) {
    //            $scope.msgError = results.data.error_message;
    //        } else {
    //            loadStudents();
    //            //alert("Atualizado!");
    //            $scope.setDefaultModel();
    //        }
    //    }, function (error) {
    //        $scope.msgError = error;
    //    });
    //};

    //    $scope.deleteStudentId = function (student) {
    //        $scope.Id = student.Id;
    //        $scope.Name = student.Name;
    //        $scope.Birthday = student.Birthday;
    //        $scope.RegistrationId = student.RegistrationId;
    //        $scope.CourseId = student.CourseId;
    //    };

    //    $scope.deleteStudent = function () {
    //        studentService.deleteStudent($scope.Id).then(function (results) {
    //            if (results.data.error_message) {
    //                $scope.msgError = results.data.error_message;
    //            } else {
    //                loadStudents();
    ///*                alert("Deletado!");*/
    //                setDefaultModel();
    //            }
    //        }, function (error) {
    //            $scope.msgError = error;
    //        });
    //    };


});
