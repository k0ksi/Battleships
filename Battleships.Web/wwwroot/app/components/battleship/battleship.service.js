(function () {

    "use strict";

    var app = angular.module("commonServices");

    app.factory("placePlayersShips",
               ["$resource",
                placePlayersShips]);

    function placePlayersShips($resource) {

        return $resource("/Battleship/PlacePlayersShips",
            {
                'update': { method: "POST" }
            });
    }

    app.factory("placeShot",
               ["$http",
                placeShot]);

    function placeShot($http) {

        $http({
            url: '/Battleship/PlaceShot',
            method: 'POST',
            data: JSON.stringify()
        })

        //return $resource('/Battleship/PlaceShot',            
        //    { "update": { method: "POST" } }
        //);

        //return $resource("/Battleship/PlaceShot",
        //    {
        //        'update': { method: "POST" }                
        //    },
        //    {
        //        'save': {
        //            transformRequest: function (data) {
        //                return JSON.stringify(data);
        //            }
        //        }
        //    }
        //);
    }

})();