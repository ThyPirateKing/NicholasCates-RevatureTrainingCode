import { Routes, Route } from 'react-router-dom';

import React from 'react';
import Weather from './Weather';
import Heaader from './Header';
import './Weather.css';
import { BrowserRouter } from 'react-router-dom';

const App = () => {
  return (
      <div>
        <Heaader></Heaader>
        <h1>Weather Forecast App</h1>
        <Weather />
      </div>
  );
};

export default App;

