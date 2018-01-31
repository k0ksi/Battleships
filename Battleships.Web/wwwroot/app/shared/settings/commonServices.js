(function () {
    "use strict";

    var app = angular
        .module("commonServices",
        ["ngResource"]);

    app.constant("appSettings",
        {
            serverPath: "http://localhost:44352/"
        });

}());