var SignalRTaskManager;
(function (SignalRTaskManager) {
    var Components;
    (function (Components) {
        var Tables;
        (function (Tables) {
            "use strict";
            var BasicTableDirective = (function () {
                function BasicTableDirective() {
                    this.restrict = "E";
                    this.scope = true;
                    this.bindToController = {
                        apiRoute: "@",
                        apiController: "@"
                    };
                    this.controller = BasicTableController;
                    this.controllerAs = "tableCtrl";
                }
                BasicTableDirective.instance = function () { return new BasicTableDirective(); };
                return BasicTableDirective;
            })();
            var BasicTableController = (function () {
                function BasicTableController($http, notificationHub) {
                    var _this = this;
                    this.$http = $http;
                    this.notificationHub = notificationHub;
                    this.loadData = function () {
                        _this.$http.get(_this.apiController).success(function (response) {
                            _this.itens = response;
                        });
                    };
                    this.loadData();
                    notificationHub.setRefresh(this.loadData);
                }
                BasicTableController.$inject = ["$http", "notificationHub"];
                return BasicTableController;
            })();
            angularTaskManager.directive("basicTable", BasicTableDirective.instance);
        })(Tables = Components.Tables || (Components.Tables = {}));
    })(Components = SignalRTaskManager.Components || (SignalRTaskManager.Components = {}));
})(SignalRTaskManager || (SignalRTaskManager = {}));
//# sourceMappingURL=BasicTableDirective.js.map