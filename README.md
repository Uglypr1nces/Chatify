## Welcome to Chatify 🚀

Chatify is an online chatting application designed for Windows users, providing a seamless and intuitive platform for real-time communication. With Chatify, users can connect with friends, colleagues, or family members effortlessly, no matter where they are.

## Table of Contents

- [Key Features](#key-features)
- [Installation](#installation)
- [Start Server](#server)
- [Contributing](#contributing)
- [Endresult](#end-result)

## Key Features

1. **Real-Time Messaging:** Enjoy instant messaging with friends and groups in real-time, making communication efficient and interactive.
2. **User-Friendly Interface:** Chatify boasts a sleek and intuitive interface, ensuring a seamless user experience for both novice and experienced users.
3. **Customization Options:** Personalize your chatting experience with customizable themes, emojis, and notification settings, making Chatify truly yours.

## Installation

### Using Visual Studio (highly recommended)

1. Install visual Studio <a href="https://visualstudio.microsoft.com/downloads">here</a>

2. Once opened, clone the repo https://github.com/Uglypr1nces/Chatify.git in Visual Studio

3. Run project, you will get a file missing error but dont worry, after youve ran it, execute the file_mover.ps1 using powershell

4. Enjoy!

### Using Command Line

1. Clone Chatify.
```bash
   git clone https://github.com/Uglypr1nces/Chatify.git
```
2. Install dotnet.
```bash
   curl -SL -o dotnet-install.ps1 https://dot.net/v1/dotnet-install.ps1
   powershell -ExecutionPolicy Bypass -File dotnet-install.ps1
   dotnet --version
```
3. Build and run the program on your Windows system.
```bash
   cd Chatify
   dotnet build Chatify.sln
```
4. Move necessary files:
```bash
    powershell -file file_mover.ps1
```
5. Enjoy!
```bash
   cd Chatify/bin/Debug
   Chatify.exe
```
## Server

1. Create ngrok account at https://ngrok.com/
2. Download ngrok
3. Move ngrok.exe in the server folder
4. Run ngrok
   ```bash
   ngrok.exe tcp 8000
   ```
5. Run python server (in a seperate terminal)
   ```bash
   python3 main.py
   ```

## Contributing

We welcome contributions from the community to help improve Chatify further. Whether it's fixing bugs, adding new features, or enhancing the UI, your contributions are highly appreciated.

## End result

<img src="content/pictures/login.png" alt="alt text">
<img src="content/pictures/chatroom.png" alt="alt text">
