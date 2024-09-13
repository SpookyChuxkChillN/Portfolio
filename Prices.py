This Python code prompts the user to enter their full name and a minimum price. It then iterates through a predefined list of prices, calculating the total sum of all prices and counting how many prices exceed the specified minimum price. Finally, it prints a greeting with the user’s name, the minimum price, the count of prices greater than the minimum price, and the total sum of all prices.
count = 0
sum = 0
full_name = input("Enter your full name: ")
min_price = float(input("Enter the minimum price: "))
price_list = [69.5, 95.6, 79.85, 41, 30.65, 55.5, 47.5, 45.3, 32, 97.85, 42.4]
for price in price_list:
    
     sum=sum+price
     if price > min_price:
         count=count+1
         
print("Hello ", full_name,", the minimum price is",min_price)   
print("There are",count,"prices greater than the minimum price")  
print("The total price is",sum)    
