import React, { useState } from 'react';
import axios from 'axios';
import './Login.css';
import { useAuth } from '../../AuthContext'; // Import the useAuth hook
import { Link } from 'react-router-dom';
function Login() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [loginStatus, setLoginStatus] = useState({ success: false, message: '' });
    const { login } = useAuth(); 

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.post('https://localhost:7128/api/login', { username, password });
            console.log(response.data);
            const userIdResponse = await axios.get(`https://localhost:7128/api/user/getUserId/${username}`);
            const userId = userIdResponse.data;

            localStorage.setItem('username', username);
            localStorage.setItem('userId', userId);
            login(username);
            setLoginStatus({ success: true, message: 'Login successful!' });
            window.location.href = '/';
        } catch (error) {
            console.error('Login failed:', error);
            setLoginStatus({ success: false, message: 'Login failed. Please try again.' });
        }
    };

    return (
        <div>
            <form onSubmit={handleSubmit} className="login-form">
                <div className="form-group">
                    <label>Username</label>
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label>Password</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button type="submit">Login</button>
            </form>
            {loginStatus.message && (
                <div className={loginStatus.success ? "success-message" : "error-message"}>
                    {loginStatus.message}
                </div>
            )}
        </div>
    );
}

export default Login;
