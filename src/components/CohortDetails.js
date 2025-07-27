// CohortDetails.js
import React from 'react';
import styles from '../Styles/CohortDetails.module.css';

function CohortDetails(props) {
  const { name, batch, status } = props;

  const titleStyle = {
    color: status === 'ongoing' ? 'green' : 'blue'
  };

  return (
    <div className={styles.box}>
      <h3 style={titleStyle}>Cohort: {name}</h3>
      <dl>
        <dt>Batch:</dt>
        <dd>{batch}</dd>
        <dt>Status:</dt>
        <dd>{status}</dd>
      </dl>
    </div>
  );
}

export default CohortDetails;
