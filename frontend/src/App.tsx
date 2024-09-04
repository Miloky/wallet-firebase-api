import React, { useEffect } from 'react';
import './App.css';
import walletService from './services/wallet-api-service';
import AccountTable from './AccountTable';







function App() {
  useEffect(()=>{
    const getDetails = async () => walletService.getAccountDetails('KT3t3p1k2Ze8LPqlXSJu');
    getDetails();


  }, []);

  return (
    <div>
      <AccountTable />
    </div>
  );
}

export default App;
