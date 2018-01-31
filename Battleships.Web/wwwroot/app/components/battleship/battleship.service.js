(function () {

    "use strict";

    var app = angular.module("commonServices");

    app.factory("getCompPlayerShipsPosition",
            ["$resource",
             getCompPlayerShipsPosition]);

    function getCompPlayerShipsPosition($resource) {

        return $resource("/Controllers/BattleshipController/CompPlayerPlaceShips",
            {
                'update': { method: "POST" }
            });
    }

})();