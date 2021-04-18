import React from 'react';
import { Switch, Route } from 'react-router-dom';

import './App.scss';

import Header from './components/header/header.component';
import MoviesPage from './pages/moviesPage';
import TvShowsPage from './pages/tvShowsPage';
import RatingsListPage from './pages/ratingsList';


const App = () => {

  return (
    <div className="app">
      <Header />
      <Switch>
          <Route exact path='/' component={MoviesPage} />
          <Route exact path='/movies' component={MoviesPage} />
          <Route exact path='/tv-shows' component={TvShowsPage} />
          <Route exact path='/ratings-list' component={RatingsListPage} />
      </Switch>
    </div>
  );
  
}

export default App;
