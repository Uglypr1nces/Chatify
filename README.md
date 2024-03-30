## Welcome to Chatify 🚀

Chatify is an online chatting application designed for Windows users, providing a seamless and intuitive platform for real-time communication. With Chatify, users can connect with friends, colleagues, or family members effortlessly, no matter where they are.

## Table of Contents
- [Key Features](#key-features)
- [Installation](#installation)
- [Contributing](#contributing)
-  [Endresult](#end-result)

## Key Features
1. **Real-Time Messaging:** Enjoy instant messaging with friends and groups in real-time, making communication efficient and interactive.
2. **User-Friendly Interface:** Chatify boasts a sleek and intuitive interface, ensuring a seamless user experience for both novice and experienced users.
3. **Customization Options:** Personalize your chatting experience with customizable themes, emojis, and notification settings, making Chatify truly yours.

## Installation

1. Clone the repository to your local machine:
```bash
   git clone https://github.com/Uglypr1nces/Chatify.git
```
2. Install the necessary dependencies.
```bash
   curl -SL -o dotnet-install.ps1 https://dot.net/v1/dotnet-install.ps1
   powershell -ExecutionPolicy Bypass -File dotnet-install.ps1
   dotnet --version
```
3. Build and run Chatify on your Windows system.
```bash
   cd Chatify
   dotnet build Chatify.sln
```
4. Move necessary files:
```bash
 powerhsell -file file_mover.ps1
```
5. Start chatting with your friends and enjoy the seamless experience!
```bash
   cd Chatify/bin/Debug
   Chatify.exe
```

## Contributing

We welcome contributions from the community to help improve Chatify further. Whether it's fixing bugs, adding new features, or enhancing the UI, your contributions are highly appreciated. Please check out our contribution guidelines for more information.


## End result
<img src="content/pictures/login.png" alt="alt text">
<img src="content/pictures/chatroom.png" alt="alt text">
