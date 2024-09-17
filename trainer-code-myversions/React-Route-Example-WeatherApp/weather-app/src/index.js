// index.js
import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import {  createBrowserRouter,  RouterProvider,} from "react-router-dom";
import App from './App';
import Weather from './Weather';
import './index.css';
import reportWebVitals from './reportWebVitals';
 
const router = createBrowserRouter([
   {
      path: "/",
      element: <App />,
   },
   {
      path: "/weather",
      element: <Weather />,
   }
])
const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
   <React.StrictMode>
      <RouterProvider router={router}/>
   </React.StrictMode>
);