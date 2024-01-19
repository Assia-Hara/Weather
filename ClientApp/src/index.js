import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import { AuthProvider } from './AuthContext'; // Import the AuthProvider

ReactDOM.render(
    <BrowserRouter>
        <AuthProvider> {/* Wrap your app with AuthProvider */}
            <App />
        </AuthProvider>
    </BrowserRouter>,
    document.getElementById('root')
);
