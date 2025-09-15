import React, { useState, useEffect } from 'react';
import axios from 'axios';
import './App.css';

const API_BASE_URL = process.env.REACT_APP_API_URL || 'https://localhost:59635'; // Use the actual API port

function App() {
  const [file, setFile] = useState(null);
  const [products, setProducts] = useState([]);
  const [uploadMessage, setUploadMessage] = useState('');
  const [loading, setLoading] = useState(false);

  // Fetch products on component mount
  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    try {
      const response = await axios.get(`${API_BASE_URL}/api/products`);
      setProducts(response.data);
    } catch (error) {
      console.error('Error fetching products:', error);
    }
  };

  const handleFileChange = (event) => {
    setFile(event.target.files[0]);
    setUploadMessage('');
  };

  const handleUpload = async () => {
    if (!file) {
      setUploadMessage('Please select a file first.');
      return;
    }

    const formData = new FormData();
    formData.append('file', file);

    setLoading(true);
    try {
      const response = await axios.post(`${API_BASE_URL}/api/products/import-csv`, formData, {
        headers: {
          'Content-Type': 'multipart/form-data',
        },
      });
      setUploadMessage('Products imported successfully!');
      setFile(null);
      document.getElementById('fileInput').value = '';
      // Refresh products list
      await fetchProducts();
    } catch (error) {
      if (error.response && error.response.data) {
        setUploadMessage(`Error: ${JSON.stringify(error.response.data)}`);
      } else {
        setUploadMessage('Error uploading file. Please try again.');
      }
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <h1>CSV Product Upload</h1>
      </header>
      
      <main className="App-main">
        <div className="upload-section">
          <h2>Upload CSV File</h2>
          <input
            id="fileInput"
            type="file"
            accept=".csv"
            onChange={handleFileChange}
            className="file-input"
          />
          <button
            onClick={handleUpload}
            disabled={loading}
            className="upload-button"
          >
            {loading ? 'Uploading...' : 'Upload CSV'}
          </button>
          {uploadMessage && (
            <div className={`message ${uploadMessage.includes('Error') ? 'error' : 'success'}`}>
              {uploadMessage}
            </div>
          )}
        </div>

        <div className="products-section">
          <h2>Products ({products.length})</h2>
          {products.length > 0 ? (
            <table className="products-table">
              <thead>
                <tr>
                  <th>ID</th>
                  <th>Name</th>
                  <th>Price</th>
                  <th>Quantity</th>
                </tr>
              </thead>
              <tbody>
                {products.map((product) => (
                  <tr key={product.id}>
                    <td>{product.id}</td>
                    <td>{product.name}</td>
                    <td>${product.price.toFixed(2)}</td>
                    <td>{product.quantity}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <p>No products found. Upload a CSV file to get started.</p>
          )}
        </div>
      </main>
    </div>
  );
}

export default App;