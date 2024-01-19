import React, { useState, useEffect } from 'react';
import { GoogleMap, Marker, InfoWindow } from '@react-google-maps/api';
import axios from 'axios';

const mapContainerStyle = {
    width: '100vw',
    height: '100vh',
};

const center = {
    lat: 34.020882, // Latitude for Rabat, Morocco
    lng: -6.841650, // Longitude for Rabat, Morocco
};

const WeatherMap = ({ googleMapsApiKey, openWeatherMapApiKey }) => {
    const [weatherData, setWeatherData] = useState(null);

    useEffect(() => {
        fetchWeatherData();
    }, []);

    const fetchWeatherData = async () => {
        try {
            const response = await axios.get(`https://api.openweathermap.org/data/2.5/weather?lat=${center.lat}&lon=${center.lng}&appid=${openWeatherMapApiKey}&units=metric`);
            setWeatherData(response.data);
        } catch (error) {
            console.error("Error fetching weather data:", error);
        }
    };

    return (
        <GoogleMap
            mapContainerStyle={mapContainerStyle}
            center={center}
            zoom={10}
            apiKey={googleMapsApiKey}
        >
            <Marker position={center} />

            {weatherData && (
                <InfoWindow position={center}>
                    <div>
                        <h2>Weather in Rabat</h2>
                        <p><strong>Temperature:</strong> {weatherData.main.temp} °C</p>
                        <p><strong>Condition:</strong> {weatherData.weather[0].main}</p>
                        <p><strong>Humidity:</strong> {weatherData.main.humidity} %</p>
                    </div>
                </InfoWindow>
            )}
        </GoogleMap>
    );
};

export default WeatherMap;
