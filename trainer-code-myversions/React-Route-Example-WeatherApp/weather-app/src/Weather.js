import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Header from './Header';

const Weather = () => {
  const [city, setCity] = useState(null);
  const [weatherData, setWeatherData] = useState(null);

  const fetchData = async () => {
    try {
      const response = await axios.get(
        `https://freetestapi.com/api/v1/weathers?search=${city}`
        //`https://api.openweathermap.org/data/2.5/weather?q=${city}&units=metric&appid={4a603408b4ad221e74586bda3c9f7f94}`
      );
      if(response.data.length === 0)
        alert('City not found');
      else
        setWeatherData(response.data);
      console.log(response.data); //You can see all the weather data in console log
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleInputChange = (e) => {
    setCity(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetchData();
  };

  return (
    <div>
      <Header></Header>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Enter city name"
          value={city}
          onChange={handleInputChange}
        />
        <button type="submit">Get Weather</button>
      </form>
      {weatherData ? (
        <>
          <h2>{weatherData[0].city}</h2>
          <p>Temperature: {weatherData[0].temperature}°C</p>
          <p>Description: {weatherData[0].weather_description}</p>
          
          <p>Humidity : {weatherData[0].humidity}%</p>
          
          <p>Wind Speed : {weatherData[0].wind_speed}m/s</p>
        </>
      ) : (
        <p>Loading weather data...</p>
      )}
    </div>
  );
};

export default Weather;