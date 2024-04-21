import socket

class Server:
    def __init__(self, server_socket,FORMAT,HEADER):
        self.server_socket = server_socket
        self.connections = []
        self.usernames = []
        self.FORMAT = FORMAT
        self.HEADER = HEADER

    def add_connection(self, conn, addr):
        self.connections.append((conn))
        print(f"New connection from {addr}, {len(self.connections)} amount of connections")
        message = f"afXMZhjvchs88vjls.g87satv0q,.7fgy{len(self.connections)}"
        for connection in self.connections:
            self.send_message(connection, message)
            self.send_message(connection, f"someone connected")

    def send_message(self, conn, msg):
        try:
            message = msg.encode(self.FORMAT)
            conn.send(message)
        except:
            self.connections.remove(conn)
            print(f"error with sending message, {conn} has been removed, {len(self.connections)} amount of connections")
            message = f"afXMZhjvchs88vjls.g87satv0q,.7fg{len(self.connections)}"
            for connection in self.connections:
                self.send_message(connection, message)
                self.send_message(connection, f"someone disconnected")


    def handle_client(self, conn, addr):
        connected = True
        try:
            while connected:
                msg = conn.recv(1024).decode(self.FORMAT)
                if msg == "!disc":
                    conn.close()
                    self.connections.remove(conn)
                    connected = False
                elif "a90sd7f8jmvsdf0sdf8asdf87a/(&()/=%?" in msg:
                    username = msg[msg.index("?") + 1:]
                    print(f"{username} has joined the chat")
                    self.usernames.append(username)
                    for connection in self.connections:
                        self.send_message(connection, f"{username} has joined the chat")

                elif msg[msg.index(" ",3) + 1] == "@":
                    try:
                        messagestart = msg.index(" ",7 + 1)
                        try:
                            # Get the username
                            start_index = msg.index("@") + 1
                            end_index = msg.index(" ", start_index)   
                            username = msg[start_index:end_index]
                            
                            message = msg[messagestart:]
                            print(f"Message to {username}: {message}")
                            for connection in self.connections:
                                if self.usernames[self.connections.index(connection)] == username:
                                    try:
                                        self.send_message(connection, message)
                                    except:
                                        print(f"Error sending '{message}' to '{addr}'")
                                        conn.send("Error sending message".encode(self.FORMAT))
                        except:
                            print("could not find username")
                            conn.send("couldnt find username".encode(self.FORMAT))

                    except:
                        print(f"Error sending '{message}' to '{addr}'")
                else:
                    for connection in self.connections:
                        self.send_message(connection,msg)

                print(msg)

        except ConnectionResetError:
            print(f"Connection with {addr} was forcibly closed.")
        finally:
            conn.close()