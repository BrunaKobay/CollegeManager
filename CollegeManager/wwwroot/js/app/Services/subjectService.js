
angular.module('app').service('subjectService', function ($http) {

    //Service to get subjects list
    this.getAll = function () {
        return $http.get("/subject/get")
            .then(function (results) {
                return results;
            }, function (err) {
                return err;
            });;
    }


    //Service to add subjects
    this.Add = function (subject) {
        var request = $http({
            method: 'POST',
            url: 'subject/create',
            data: subject
        });

        return request;
    }

    //Service to edit subjects
    this.Edit = function (subject) {
        var request = $http({
            method: 'POST',
            url: 'subject/edit',
            data: student
        });

        return request;
    }

    //Service to delete subjects
    this.Delete = function (subject) {
        return $http.post('subject/delete/' + subject);
   
    }

});