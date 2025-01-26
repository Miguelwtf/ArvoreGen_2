import { BrowserRouter as Router } from 'react-router-dom';
import App from './App'; 
import React from 'react';
import ReactDOM from 'react-dom/client';
import '@coreui/coreui/dist/css/coreui.min.css';
//import 'bootstrap/dist/css/bootstrap.min.css';
import './styles/global.css';

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <Router>
            <App />
        </Router>
    </React.StrictMode>
);
