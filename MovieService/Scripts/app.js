var ViewModel = function () {
    var self = this;
    self.detail = ko.observable();
    self.selectedDirector = ko.observable();
    self.movies = ko.observableArray();
    self.directors = ko.observableArray();
    self.error = ko.observable();

    var moviesUri = '/api/movies/';
    var directorsUri = '/api/directors/';

    self.newMovie = {
        Director: ko.observable(),
        Genre: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable()
    }

    self.newDirector = {
        Name: ko.observable()
    }

    self.getMovieDetail = function (item) {
        ajaxHelper(moviesUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }
    
    self.deleteMovie = function (item) {
        ajaxHelper(moviesUri + item.Id, 'DELETE').done(function (data) {
            self.movies.remove(item);
        });
    }

    self.deleteDirector = function () {
        ajaxHelper(directorsUri + self.selectedDirector().Id, 'DELETE').done(function (data) {
            self.directors.remove(self.selectedDirector());
        });
    }

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllMovies() {
        ajaxHelper(moviesUri, 'GET').done(function (data) {
            self.movies(data);
        });
    }

    function getDirectors() {
        ajaxHelper(directorsUri, 'GET').done(function (data) {
            self.directors(data);
        });
    }

    self.addMovie = function (formElement) {
        var movie = {
            DirectorId: self.newMovie.Director().Id,
            Genre: self.newMovie.Genre(),
            Title: self.newMovie.Title(),
            Year: self.newMovie.Year()
        };

        ajaxHelper(moviesUri, 'POST', movie).done(function (item) {
            self.movies.push(item);
        });
    }

    self.addDirector = function (formElement) {
        var director = {
            Name: self.newDirector.Name()
        };

        ajaxHelper(directorsUri, 'POST', director).done(function (item) {
            self.directors.push(item);
        });
    }

    getDirectors();

    // Fetch the initial data.
    getAllMovies();
};

ko.applyBindings(new ViewModel());