(function () {

    "use strict";

    var app = angular.module("app",
        ["commonServices"]);

    app.controller("BattleshipController",
        [
            "$scope",
            "$timeout",
            "placePlayersShips",
            "placeShot",
            BattleshipGame
        ]);

    function BattleshipGame($scope, $timeout, placePlayersShips, placeShot) {

        var occupationTypes = [0, 1, 2, 3, 4, 5];
        var hasLoaded = false;
        $scope.showPreloader = true;
        $scope.respondingClassName = ['', 'ship', 'ship', 'ship', 'hit', 'miss'];
        $scope.yourTurnToShoot = true;
        $scope.model = {};

        $scope.initData = function () {

            placePlayersShips.save({},
                $scope.model,
                function (data) {
                    $scope.model = angular.copy(data);

                    hasLoaded = true;
                });  
        };

        $scope.getClass = getClass;
        $scope.getClassSecond = getClassSecond;
        $scope.placeShot = placePlayerShot;

        function placePlayerShot(row, col) {

            $scope.model.selectedRow = row;
            $scope.model.selectedCol = col;
            
            placeShot.save({},
                JSON.stringify($scope.model),
                //{
                //    firstPlayer: $scope.model.firstPlayer,
                //    secondPlayer: $scope.model.secondPlayer,
                //    selectedRow: $scope.model.selectedRow,
                //    selectedCol: $scope.model.selectedCol
                //},
                function (data) {
                    $scope.model = angular.copy(data);
                });
        }

        function getClass(row, col, isGamingBoard) {
            if (!hasLoaded)
                return '';

            var panels = [];
            panels = isGamingBoard ? $scope.model.firstPlayer.gameBoard.panels : $scope.model.firstPlayer.firingBoard.panels;
            var filteredPanels = filterPanels(panels, row, col);
            if (filteredPanels.length == 0) 
                return '';

            var currentPanel = filteredPanels[0];
            var className = $scope.respondingClassName[currentPanel.blockType]

            return className;
        };

        function getClassSecond(row, col, isGamingBoard) {
            if (!hasLoaded)
                return '';

            var panels = [];
            panels = isGamingBoard ? $scope.model.secondPlayer.gameBoard.panels : $scope.model.secondPlayer.firingBoard.panels;
            var filteredPanels = filterPanels(panels, row, col);
            if (filteredPanels.length == 0)
                return '';

            var currentPanel = filteredPanels[0];
            var className = $scope.respondingClassName[currentPanel.blockType]

            return className;
        };

        function filterPanels(panels, row, col) {

            var filteredPanels = panels
                .filter(panel => panel.coordinates.row == row &&
                    panel.coordinates.column == col);

            return filteredPanels;
        }

        $timeout(function () {
            $scope.showPreloader = false
        }, 700);
    };

})();