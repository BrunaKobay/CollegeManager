
//teachers controller
app.controller('teacherController', function ($scope, baseService) {


    $scope.objData = [];
    $scope.msgError = "";
    $scope.objModel = {};

    $scope.coursesList = [];
    $scope.enrollmentsList = [];


    baseService.SetAlias('teacher');

    $scope.GetCourseList = function () {
        baseService.GetByModel('course').then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.coursesList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };



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
            Salary: "",
            Subjects: ""
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
            Salary: $scope.objModel.Salary,
            Subjects: $scope.objModel.Subjects
        };

        baseService.Save(objForm).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.GetList();
                $scope.setDefaultModel();
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
            Salary: model.Salary,
            Subjects: model.Subjects,
        };
    };

    $scope.edit = function () {
        var objForm = {
            Id: $scope.objModel.Id,
            Name: $scope.objModel.Name,
            Birthday: $scope.objModel.Birthday,
            Salary: $scope.objModel.Salary,
            Subjects: $scope.objModel.Subjects
        };

        baseService.Edit(objForm).then(function (results) {
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.GetList();
                $scope.setDefaultModel();
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
            if (results.data.error_message) {
                $scope.msgError = results.data.error_message;
            } else {
                $scope.GetList();
                $scope.setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

});