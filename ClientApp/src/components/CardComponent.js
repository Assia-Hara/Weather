import React from 'react';

const CardComponent = ({ imageUrl }) => {
    return (
        <div style={styles.container}>
            <div style={styles.card}>
                <img src={imageUrl} alt="Card" style={styles.image} />
            </div>
        </div>
    );
};

const styles = {
    container: {
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#f0f0f0', // Optional background color
    },
    card: {
        width: '644px', // Adjust the card width as needed
        padding: '20px',
        boxShadow: '0 2px 4px rgba(0, 0, 0, 0.1)',
        backgroundColor: 'white',
        textAlign: 'center',
    },
    image: {
        maxWidth: '100%',
        height: 'auto',
    },
};

export default CardComponent;
