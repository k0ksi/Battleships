(function () {

    "use strict";

    var app = angular.module("commonServices");

    app.factory("getCompPlayerShipsPosition",
               ["$resource",
                getCompPlayerShipsPosition]);

    function getCompPlayerShipsPosition($resource) {

        return $resource("/Battleship/CompPlayerPlaceShips",
            {
                'update': { method: "POST" }
            });
    }

})();