import React, { Component } from 'react';
import axios from 'axios';

import WeatherInfo from './WeatherInfo';

export class Home extends Component {
    static displayName = Home.name;
    state = {
        currentCity: '',
        weatherData: null,
    };

    componentDidMount() {
        navigator.geolocation.getCurrentPosition(
            async (position) => {
                const { latitude, longitude } = position.coords;
                localStorage.setItem('latitude', latitude);
                localStorage.setItem('longitude', longitude);

                const city = await this.getCityName(latitude, longitude);
                this.setState({ currentCity: city });

                this.fetchWeatherData(latitude, longitude);
            },
            (error) => console.error(error),
            { enableHighAccuracy: true, timeout: 10000, maximumAge: 0 }
        );
    }

    fetchWeatherData = async (latitude, longitude) => {
        try {
            const response = await axios.get(`https://localhost:7128/api/WeatherData/getWeatherByLocation/${latitude}/${longitude}`);
            console.log('Weather Data:', response.data);
            this.setState({ weatherData: response.data });
        } catch (error) {
            console.error('Error fetching weather data:', error);
        }
    };

    saveWeatherData = async () => {
        const userId = localStorage.getItem('userId');
        const latitude = localStorage.getItem('latitude');
        const longitude = localStorage.getItem('longitude');

        if (userId && latitude && longitude) {
            try {
                const payload = {
                    userId: parseInt(userId), // Ensure userId is an integer, if it's stored as a string
                    latitude: parseFloat(latitude), // Parse latitude as float
                    longitude: parseFloat(longitude), // Parse longitude as float
                };

                const response = await axios.post('https://localhost:7128/api/UserWeatherData', payload);
                console.log('Response:', response); // Log the response here

                // Additional handling of response if needed
            } catch (error) {
                console.error('Error saving weather data:', error);
                // Handle error
            }
        }
    };

    async getCityName(latitude, longitude) {
        try {
            const response = await fetch(`https://nominatim.openstreetmap.org/reverse?format=json&lat=${latitude}&lon=${longitude}`);
            const data = await response.json();
            return data.address.city || data.address.town || data.address.village; // Adjust based on API response
        } catch (error) {
            console.error('Error fetching city name:', error);
            return ''; // Return empty string or handle error as needed
        }
    }

    // Helper function to format the date and time
    formatDateAndTime() {
        const currentDate = new Date();
        const options = {
            weekday: 'long',
            day: 'numeric',
            month: 'long',
            year: 'numeric',
            hour: 'numeric',
            minute: 'numeric',
            timeZoneName: 'short',
        };
        return currentDate.toLocaleDateString('en-US', options);
    }

    render() {
        const currentDateTime = this.formatDateAndTime();
        const { currentCity, weatherData } = this.state;

        const styles = {
            container: {
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center', // Center horizontally
                justifyContent: 'center', // Center vertically
                textAlign: 'center',
            },
            weatherInfoContainer: {
                marginTop: '20px',
            },
        };

        return (
            <div style={styles.container}>
                <h1>
                    Weather Maroc - <span style={{ color: 'red' }}>{currentDateTime}</span>
                </h1>
                {currentCity && <h2>Current City: {currentCity}</h2>}

                <div style={styles.weatherInfoContainer}>
                    {weatherData && <WeatherInfo weatherData={weatherData} />}
                </div>
            </div>
        );
    }
}
