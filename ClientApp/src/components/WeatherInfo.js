import React, { useState, useEffect } from 'react';
import axios from 'axios';
import Autosuggest from 'react-autosuggest';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTemperatureHigh, faTint, faCompress } from '@fortawesome/free-solid-svg-icons';

const WeatherInfo = () => {
    const [value, setValue] = useState('');
    const [suggestions, setSuggestions] = useState([]);
    const [weatherData, setWeatherData] = useState(null);
    const [selectedCity, setSelectedCity] = useState(null);
    const [cityList, setCityList] = useState([
        { name: 'Casablanca', latitude: 33.5731, longitude: -7.5898 },
        { name: 'Rabat', latitude: 34.0209, longitude: -6.8416 },
        { name: 'Marrakech', latitude: 31.6295, longitude: -7.9811 },
        // Add more cities with their latitude and longitude
    ]);

    // Retrieve latitude and longitude from localStorage
    const storedLatitude = localStorage.getItem('latitude');
    const storedLongitude = localStorage.getItem('longitude');

    const getSuggestions = (inputValue) => {
        const inputLowerCase = inputValue.trim().toLowerCase();
        return cityList.filter((city) => city.name.toLowerCase().includes(inputLowerCase));
    };

    const getSuggestionValue = (suggestion) => suggestion.name;

    const renderSuggestion = (suggestion) => <div>{suggestion.name}</div>;

    const onSuggestionsFetchRequested = ({ value }) => {
        setSuggestions(getSuggestions(value));
    };

    const onSuggestionsClearRequested = () => {
        setSuggestions([]);
    };

    const onChange = (_, { newValue }) => {
        setValue(newValue);
    };

    const onSuggestionSelected = (_, { suggestion }) => {
        setSelectedCity(suggestion);
    };

    const getWeatherByLocation = async () => {
        try {
            const response = await axios.get(
                `https://localhost:7128/api/WeatherData/getWeatherByLocation/${selectedCity.latitude}/${selectedCity.longitude}`
            );
            setWeatherData(response.data);
        } catch (error) {
            console.error('Error fetching weather data:', error);
        }
    };

    const [forecastData, setForecastData] = useState(null);

    // Inside the getWeatherForecast function
    const [weatherForecast, setWeatherForecast] = useState(null);

    const getWeatherForecast = async () => {
        try {
            const response = await axios.get(
                `https://localhost:7128/api/WeatherData/getWeatherForecast/${selectedCity.latitude}/${selectedCity.longitude}`
            );

            // Assuming the response.data is an array of strings for each day's forecast
            const formattedForecast = response.data.join(', ');

            setWeatherForecast(formattedForecast);
        } catch (error) {
            console.error('Error fetching weather forecast data:', error);
        }
    };

    const formatForecastData = (forecastData) => {
        return forecastData.map((forecastItem) => {
            return {
                date: forecastItem.date,  // Ensure the property names match the actual structure
                temperature: forecastItem.temperature,
            };
        });
    };


    const groupForecastByDay = (forecastData) => {
        // Group the forecast data by date
        const groupedData = forecastData.reduce((acc, forecast) => {
            const date = forecast.date.split(' ')[0]; // Extract date part only
            if (!acc[date]) {
                acc[date] = [];
            }
            acc[date].push(forecast);
            return acc;
        }, {});

        // Map the grouped data to an array
        const formattedData = Object.entries(groupedData).map(([date, forecasts]) => {
            return {
                date,
                temperatures: forecasts.map((forecast) => forecast.temperature),
            };
        });

        return formattedData;
    };


    useEffect(() => {
        // Use latitude and longitude from localStorage
        if (storedLatitude && storedLongitude) {
            const matchedCity = cityList.find(
                (city) =>
                    city.latitude === parseFloat(storedLatitude) &&
                    city.longitude === parseFloat(storedLongitude)
            );

            if (matchedCity) {
                setSelectedCity(matchedCity);
                setValue(matchedCity.name);
                getWeatherByLocation(); // Fetch weather data for the user's location
            }
        }
    }, [cityList]);

    const styles = {
        container: {
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center', // Center horizontally
            justifyContent: 'center', // Center vertically
            maxWidth: '400px',
            margin: '20px auto',
            marginRight: 'auto', // Add this line to control the maximum right spacing
            padding: '20px',
            backgroundColor: '#fff',
            border: '1px solid #e0e0e0',
            borderRadius: '8px',
            boxShadow: '0 0 10px rgba(0, 0, 0, 0.1)',
            width: '80%', // Adjust the width as needed
        },
        heading: {
            color: '#333',
            marginBottom: '15px',
        },
        autosuggest: {
            width: '100%', // Make the autosuggest input full-width
            position: 'relative',
            marginBottom: '10px',
        },
        button: {
            backgroundColor: '#af4c68',
            color: '#fff',
            padding: '10px',
            cursor: 'pointer',
            border: 'none',
            borderRadius: '4px',
            fontSize: '16px',
            marginTop: '10px', // Add margin top to the button
        },
        weatherData: {
            marginTop: '20px',
            width: '100%', // Make the weather data container full-width
        },
        weatherHeading: {
            marginBottom: '10px',
            color: '#333',
        },
        weatherInfo: {
            margin: '5px 0',
            color: '#555',
        },
    };

    return (
        <div style={styles.container}>
            <h2 style={styles.heading}>Weather Information by City</h2>
            <Autosuggest
                suggestions={suggestions}
                onSuggestionsFetchRequested={onSuggestionsFetchRequested}
                onSuggestionsClearRequested={onSuggestionsClearRequested}
                getSuggestionValue={getSuggestionValue}
                renderSuggestion={renderSuggestion}
                inputProps={{
                    placeholder: 'Type a city',
                    value,
                    onChange,
                    onBlur: () => onSuggestionSelected(null, { suggestion: selectedCity }),
                }}
                onSuggestionSelected={onSuggestionSelected}
                style={styles.autosuggest}
            />
            <button style={styles.button} onClick={getWeatherByLocation} disabled={!selectedCity}>
                Get Weather
            </button>

            {weatherData && (
                <div style={styles.weatherData}>
                    <h3 style={styles.weatherHeading}>Weather Data for {selectedCity.name}</h3>
                    <p style={styles.weatherInfo}>
                        <FontAwesomeIcon icon={faTemperatureHigh} /> Temperature: {weatherData.temperature} {String.fromCharCode(176)}C
                    </p>
                    <p style={styles.weatherInfo}>
                        <FontAwesomeIcon icon={faTint} /> Humidity: {weatherData.humidity}%
                    </p>
                    <p style={styles.weatherInfo}>
                        <FontAwesomeIcon icon={faCompress} /> Pressure: {weatherData.pressure} hPa
                    </p>
                    {/* Add other weather data fields as needed */}
                </div>
            )}

            <button onClick={getWeatherForecast} disabled={!selectedCity}>
                Get Todays Forecast
            </button>

            <button onClick={getWeatherForecast} disabled={!selectedCity}>
                Get Yesterday Forecast
            </button>

            {weatherForecast && (
                <div>
                    <h3>Weather Forecast for {selectedCity.name}</h3>
                    <p>{weatherForecast}</p>
                </div>
            )}

        </div>
    );
};

export default WeatherInfo;
