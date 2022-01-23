'use strict';
angular.module('app').service('baseService', ['$http', function ($http) {

    var objServiceFactory = {};
    var strAlias = '';

    var _getList = function () {
        return $http.get('/' + strAlias + '/get')
            .then(function (results) {
                return results;
            }, function (err) {
                return err;
            });
    };

    var _save = function (c) {
        return $http.post('/' + strAlias + '/create', c).then(function (results) {
            return results;
        }, function (err) {
            return err;
        });
    };

    var _edit = function (c) {
        return $http.post('/' + strAlias + '/edit', c, { headers: { 'Content-Type': 'application/json' } }).then(function (results) {
            return results;
        }, function (err) {
            return err;
        });
    };

    var _delete = function (c) {
        return $http.post('/' + strAlias + '/delete/' + c, { headers: { 'Content-Type': 'application/json' } }).then(function (results) {
            return results;
        }, function (err) {
            return err;
        });
    };

    var _setAlias = function (alias) {
        strAlias = alias;
    }

    var _getById = function (id) {
        return $http.get('/' + strAlias + '/getbyid?id=' + id).then(function (results) {
            return results;
        }, function (err) {
            return err;
        });
    };

    var _getListByModel = function (model) {
        return $http.get('/' + model + '/get')
            .then(function (results) {
                return results;
            }, function (err) {
                return err;
            });
    };

    objServiceFactory.GetList = _getList;
    objServiceFactory.Save = _save;
    objServiceFactory.Delete = _delete;
    objServiceFactory.SetAlias = _setAlias;
    objServiceFactory.GetById = _getById;
    objServiceFactory.Edit = _edit;
    objServiceFactory.GetByModel = _getListByModel;

    return objServiceFactory;

}]);