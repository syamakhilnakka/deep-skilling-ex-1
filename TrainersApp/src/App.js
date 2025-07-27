// App.js
import React from 'react';
import { BrowserRouter, Routes, Route, Link } from 'react-router-dom';
import Home from './Home';
import TrainerList from './TrainerList';
import TrainerDetail from './TrainerDetail';
import trainers from './TrainersMock';

function App() {
  return (
    <BrowserRouter>
      <div>
        <h1>Trainers Application</h1>
        <nav>
          <Link to="/">Home</Link> | <Link to="/trainers">Trainer List</Link>
        </nav>

        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/trainers" element={<TrainerList trainers={trainers} />} />
          <Route path="/trainer/:id" element={<TrainerDetail />} />
        </Routes>
      </div>
    </BrowserRouter>
  );
}

export default App;
