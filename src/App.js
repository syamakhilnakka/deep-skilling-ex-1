// App.js
import React from 'react';
import CohortDetails from './Components/CohortDetails';

function App() {
  return (
    <div className="App">
      <h1>My Academy Dashboard</h1>
      <CohortDetails name="React Basics" batch="June 2025" status="ongoing" />
      <CohortDetails name="Advanced Java" batch="May 2025" status="completed" />
    </div>
  );
}

export default App;
