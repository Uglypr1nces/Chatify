import socket

class Server:
    def __init__(self, server_socket, FORMAT, HEADER):
        self.server_socket = server_socket
        self.connections = []
        self.usernames = []
        self.FORMAT = FORMAT
        self.HEADER = HEADER

    def add_connection(self, conn, addr):
        self.connections.append(conn)
        print(f"New connection from {addr}, {len(self.connections)} amount of connections")
        message = f"afXMZhjvchs88vjls.g87satv0q,.7fgy{len(self.connections)}"
        for connection in self.connections:
            self.send_message(connection, message)
  
    def remove_connection(self, conn):
        try:
            index = self.connections.index(conn)
            self.connections.remove(index)
            username = self.usernames.pop(index)
            self.usernames.remove(index)
            for connection in self.connections:
                self.send_message(connection, f"{username} has left the chat.")
            conn.close()
            print(f"Connection with {addr} closed.")
        except:
            print("Error removing connection")

    def send_message(self, conn, msg):
        try:
            message = msg.encode(self.FORMAT)
            conn.send(message)
        except Exception as e:
            print(f"Error sending message: {e}")
            self.remove_connection(conn)

    def handle_client(self, conn, addr):
        try:
            while True:
                msg = conn.recv(1024).decode(self.FORMAT)
                if not msg:
                    print(f"Connection with {addr} closed.")
                    try:
                        self.remove_connection(conn)
                    except:
                        print("Error removing connection")
                    break

                if msg == "!disc":
                    conn.close()
                    self.remove_connection(conn)
                    print(f"Connection with {addr} closed.")
                    break

                elif "a90sd7f8jmvsdf0sdf8asdf87a/(&()/=%?" in msg:
                    username = msg[msg.index("?") + 1:]
                    print(f"{username} has joined the chat")
                    self.usernames.append(username)
                    for connection in self.connections:
                        self.send_message(connection, f"{username} has joined the chat")

                elif "@" in msg:
                    try:
                        messagestart = msg.index(" ",7 + 1)
                        try:
                            # Get the username
                            start_index = msg.index("@") + 1
                            end_index = msg.index(" ", start_index)   
                            username = msg[start_index:end_index]
                            sender = msg[3:msg.index(":" + 1)]
                            message = msg[messagestart:]
                            print(f"Message to {username}: {message}")
                            for connection, username in self.usernames.items():
                                if username == username:
                                    try:
                                        self.send_message(connection, sender + ":" + message)
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


