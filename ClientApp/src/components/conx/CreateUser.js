import React, { useState } from 'react';
import axios from 'axios';
import './CreateUser.css';
function CreateUser() {
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [message, setMessage] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        try {
            const response = await axios.post('https://localhost:7128/api/user', { username, email, password });
            console.log(response.data);
            setMessage('User created successfully');
        } catch (error) {
            console.error('Error creating user:', error);
            setMessage('Error creating user. Please try again.');
        }
    };

    return (
        <div className="create-user-form">
            <h2>Create User</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Username</label>
                    <input
                        type="text"
                        value={username}
                        onChange={(e) => setUsername(e.target.value)}
                    />
                </div>
                <div>
                    <label>Email</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div>
                    <label>Password</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button type="submit">Create User</button>
            </form>
            {message && <p>{message}</p>}
        </div>
    );
}

export default CreateUser;
