import axios from 'axios';

// const API_URL: string = 'http://localhost:5098';
const API_URL: string = 'http://34.226.198.6';

class WalletService {
    // TODO: add types
    public async getAccountDetails(accountId: string): Promise<any>{
        const path = `${API_URL}/accounts/${accountId}`;
        const responseData = await axios({
            method: 'GET',
            url: path
        });
        console.log(responseData.data);
    }
}

const walletService = new WalletService();
export default walletService;