(function () {

    "use strict";

    var app = angular.module("app",
        ["commonServices"]);

    app.controller("BattleshipController",
        [
            "getCompPlayerShipsPosition",
            BattleshipGame
        ]);

    function BattleshipGame(getCompPlayerShipsPosition) {

        var vm = this;

        vm.model = {};

        vm.getCompPlayerShipsPosition = getCompPlayerShipsPosition;

        vm.initData = function () {

            vm.getCompPlayerShipsPosition();
        };

        vm.getCompPlayerShipsPosition.save({},
            vm.model,
            function (data) {
                vm.model = angular.copy(data);
            })
    };

})();