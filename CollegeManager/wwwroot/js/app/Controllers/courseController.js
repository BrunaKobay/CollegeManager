//subjects controller
app.controller('courseController', function ($scope, baseService, enrollmentService) {


    $scope.objData = [];
    $scope.msgError = "";
    $scope.objModel = {};

    $scope.studentsList = [];

    baseService.SetAlias('course');



    $scope.GetCourseDetails = function () {
        baseService.GetCourseDetails().then(function (results) {
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
            CourseId: "",
            CourseName: "",
        };
    };

    $scope.GetCourseDetails();
    setDefaultModel();

    $scope.Cancel = function () {
        setDefaultModel();
    };

    $scope.Save = function () {
        var objForm = {
            Name: $scope.objModel.CourseName
        };

        baseService.Save(objForm).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.GetCourseDetails();
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
        };
    };

    $scope.edit = function () {
        var objForm = {
            Id: $scope.objModel.Id,
            Name: $scope.objModel.Name,
        };

        baseService.Edit(objForm).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.GetCourseDetails();
                setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

    $scope.deleteId = function (model) {
        $scope.objModel = {
            Id: model.courseId,
            Name: model.courseName
        };
    };

    $scope.delete = function () {
        baseService.Delete($scope.objModel.Id).then(function (results) {
            if (results.data.error) {
                $scope.msgError = results.data.error;
            } else {
                $scope.GetCourseDetails();
                $scope.setDefaultModel();
            }
        }, function (error) {
            $scope.msgError = error;
        });
    };

   

});