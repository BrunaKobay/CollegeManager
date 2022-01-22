
angular.module('app').service('studentService', function ($http) {

    //Service to get students list
    this.getAllStudents = function () {
        return $http.get("/student/get")
            .then(function (results) {
                return results;
            }, function (err) {
                return err;
            });;
    }

    //Service to get all enrollments with subjctID
    this.getEnrollmentBySubjectId = function (id) {
        return $http.post('enrollment/GetBySubjectId/' + id);
   
    }

});