import socket

class Server:
    def __init__(self, server_socket, FORMAT, HEADER):
        self.server_socket = server_socket
        self.connections = []
        self.usernames = []
        self.FORMAT = FORMAT
        self.HEADER = HEADER

    def add_connection(self, addr, conn):
        self.connections.append(conn)
        print(f"Connection from {addr} has been established")
        print(f"Amount of connections: {len(self.connections)}")
        for connection in self.connections:
            message = f"afXMZhjvchs88vjls.g87satv0q,.7fg{len(self.connections)}"
            self.send_message(connection, message)

    def send_message(self, conn, msg):
        try:
            message = msg.encode(self.FORMAT)
            conn.send(message)
        except Exception as e:
            print(f"Error sending message: {e}")
            self.connections.remove(conn)

    def handle_client(self, conn, addr):
        try:
            while True:
                msg = conn.recv(1024).decode(self.FORMAT)
                if not msg:
                    print(f"Connection with {addr} closed.")
                    self.connections.remove(conn)
                    break
                if msg == "!disc":
                    conn.close()
                    self.connections.remove(conn)
                    print(f"Connection with {addr} closed.")
                    break
                elif "a90sd7f8jmvsdf0sdf8asdf87a/(&()/=%?" in msg:
                    username = msg[35:]
                    self.usernames.append(username)
                    for connection in self.connections:
                        for username_tosend in self.usernames:
                            self.send_message(connection, f"a90sd7f8jmvsdf0sdf8asdf87a/(&()/=%?{username_tosend}")
                elif "@" in msg:
                    try:
                        username_end_idx = msg.index(" ", 3)
                        username = msg[3:username_end_idx]
                        message = msg[username_end_idx + 1:]
                        print(f"Message to {username}: {message}")
                        for connection in self.connections:
                            if self.usernames[self.connections.index(connection)] == username:
                                self.send_message(connection, message)
                    except Exception as e:
                        print(f"Error sending message to {username}: {e}")
                else:
                    for connection in self.connections:
                        if connection != conn:
                            self.send_message(connection, msg)
                    print(msg)
        except Exception as e:
            print(f"Error handling client: {e}")
            conn.close()
