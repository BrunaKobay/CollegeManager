
angular.module('app').service('enrollmentService', function ($http) {


    //Service to get all enrollments with subjctID
    this.getEnrollmentBySubjectId = function (id) {
        return $http.post('enrollment/GetBySubjectId/' + id);

    }


    //Service to get all enrollments with studentID
    this.getEnrollmentByStudentId = function (id) {
        return $http.post('enrollment/GetByStudentId/' + id);

    }

});