var App = angular.module("APP", ["ngRoute"]);
// konfigurere våre ruter
App.config(['$routeProvider', function ($routeProvider) {
    $routeProvider

        // rute for FAQ side
        .when('/faq', {
            templateUrl: 'pages/faq.html',
            controller: 'FAQController'
        })
        // rute for kundeservice side
        .when('/kundeservice', {
            templateUrl: 'pages/kundeservice.html',
            controller: 'kundeserviceController'
        })
        // rute for kontakt side
        .when('/kontakt', {
            templateUrl: 'pages/kontakt.html',
            controller: 'kontaktController'
        }).
      otherwise({
        redirectTo: '/faq'
    });
}]);
App.controller("FAQController", function ($scope, $http, $route) {
    var urlFaqer = '/api/FAQ/Faqer';

    function henteAlleFaqer() {
        
        $http.get(urlFaqer).
          success(function (alleFaqer) {
              $scope.faqr = alleFaqer;
              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.visFaq = true;
    $scope.laster = true;
    $scope.kategorier = true;
  henteAlleFaqer();

  $scope.visFaqSporsmal = function (id) {
     
      $scope.valgtKat = id;
      console.log("kat: " + id);
      henteAlleFaqer();
     
  };
  
 
  $scope.back = function () {
     
      $route.reload();
  };

  var urlKatagorier = '/api/FAQ/Katagorier';

  function henteAlleKatagorier() {

    
      $http.get(urlKatagorier).
        success(function (alleKatagorier) {
            $scope.kategorier = alleKatagorier; //henter ut alle kategorier i en meny
            $scope.laster = false;
        }).
        error(function (data, status) {
            console.log(status + data);
        });
  };
  henteAlleKatagorier();
});

// create the controller and inject Angular's $scope
App.controller("kundeserviceController", function ($scope, $http) {
       
    
    var urlKunder = '/api/FAQ/KundeSporsmol';

    function hentAlleKundeSporsmoler() {
        $http.get(urlKunder).
          success(function (alleKundeSporsmoler) {
              $scope.kundeSporsmoler = alleKundeSporsmoler;
              $scope.laster = false;
                console.log(alleKundeSporsmoler);
            }).
          error(function (data, status) {
              console.log(status + data);
          });
    };

    $scope.visKunder = true;
    $scope.laster = true;
    hentAlleKundeSporsmoler();
   
});



App.controller("kontaktController", function ($scope, $http, $route) {

    var urlKunder = '/api/FAQ/KundeSporsmol';
    var urlKatagorier = '/api/FAQ/Katagorier';
 
    $scope.visSkjema = true;
    $scope.registrering = true;

   function henteAlleKatagorier() {

       
        $http.get(urlKatagorier).
          success(function (alleKatagorier) {
              $scope.Katagorier = alleKatagorier;
              $scope.laster = false;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
   henteAlleKatagorier();

   $scope.nulStill = function () {
       $route.reload();
    }


    $scope.lagreKundeSporsmol = function () {
        // lag et object for overføring til server via post
        
        var kundesporsmol = {
            Navn: $scope.Navn,
            Email: $scope.Email,
            KatagoriId: $scope.Katagori.Id,
            Sporsmoltext: $scope.KundeSporsmol

        };

        $route.reload();
        $http.post(urlKunder, kundesporsmol).
          success(function (data) {
          }).
          error(function (data, status) {
              console.log(status + data);
          });
       
    };

});


