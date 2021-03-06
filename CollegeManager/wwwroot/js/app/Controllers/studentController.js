//students controller
app.controller('studentController', function ($scope, baseService, enrollmentService) {


    $scope.objData = [];
    $scope.msgError = "";
    $scope.objModel = {};

    $scope.enrollmentsList = [];

    baseService.SetAlias('student');

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

    $scope.delete= function () {
        baseService.Delete($scope.objModel.Id).then(function (results) {
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

    


    //STUDENTS GRADES AREA
    $scope.showGrades = function (model) {
        $scope.StudentName = model.Name;
        $scope.StudentId = model.Id;
        enrollmentService.getEnrollmentByStudentId(model.Id).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.enrollmentsList = results.data;
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };


});
