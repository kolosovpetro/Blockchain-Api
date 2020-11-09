# Blockchain API

Blockchain API Demo using ASP NET Core.

## Blockchain definition

*Blockchain* -- As data structure, blockchain is a back-linked list of blocks of transactions, which is ordered. It can be stored as a flat file or in a simple database. Each block is identifiable by a hash, generated using the SHA256 cryptographic hash algorithm on the header of the block.

## Endpoints

- GET: GetAllBlocks -- Returns the list of all blocks in blockchain.
- GET: GetBalance -- Returns balance of particular miner address. Address is a string.
- GET: IsValidChain -- Checks whenever blockchain is valid.
- POST: MineBlock -- Mines new block and creates a transaction to particular miner address. Keep the address in order to check balance later.

## Links:

- Github: https://github.com/kolosovpetro/Blockchain-Api
- Heroku: https://blockchain-web-api.herokuapp.com/swagger
