#TODO
Io andrei sull'interfaccia iGraph e cambierei la Draw(...) aggiungendoci: Draw(.... , int centroX, int centroY)poi questo comporta che dovrai andare in MAP ed aggiungerle anche li. Ora hai di nuovo in draw le 2 coordinate di centro del PG (che sostituiscono StartX e Y)Infine in Game1 => Draw, nel ciclo Foreach che parsa tutte le classi con interfaccia IGraph aggiungi dopo il .DRAW(spriteBatch, MioPG.X, MioPG.Y); dove MioPG.X e .Y sono le variabili che hai creato nel PGClass.quando implementerai il movimento, il PG cambierà questi valori ed avrai lo spostamento in mappa

#Appunti
* variabile => è una variabile della funzione, inizializzata e morta all'interno della funzione
* _variabile => è una variabile privata della classe che puoi usare in tutte le funzioni
* Variabile => è una variabile pubblica o protetta della classe a cui puoi accedere dall'interno o dall'esterno
