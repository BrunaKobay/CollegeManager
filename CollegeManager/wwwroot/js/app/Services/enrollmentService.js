
angular.module('app').service('enrollmentService', function ($http) {


    //Service to get all enrollments with subjctID
    this.getEnrollmentBySubjectId = function (id) {
        return $http.post('enrollment/GetBySubjectId/' + id);

    }

});