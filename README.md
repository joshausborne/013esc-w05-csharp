# Overview

This is my very first C# project. It is an example of how to pull current stock prices, and compare them with the cost basis per share. It also prints out a percentage loss or percentage gain since purchase.

# Development Environment

I initially wrote this in .NET 8.0, but I changed computers during the development cycle, and the older computer is not supported by .NET 8.0, so I had to rebuild it with .NET 6.0 instead.

The only library being used in this is Newtonsoft.json.

# Useful Websites

- [Codecademy - Learn C# ](https://www.codecademy.com/catalog/language/c-sharp)
- [Alpha Vantage](https://www.alphavantage.co/)

# Future Work

- I'd rather not have the API key in the committed file, but it's just a free key that anybody can get, so I'm not worried about this one in particular. Ideally, the key would be stored in a separate included config file.
- I'd love to have included a count of shares owned, so as to determine the total investment along with the total gained/lost.
- I'd also like to include a way to calculate how each share would need to increase in price for it to break even.
- Perhaps I could have this run each evening and store the daily close info. This way we could plot the stock price over time. 
