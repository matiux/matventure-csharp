#TODO
* Io andrei sull'interfaccia iGraph e cambierei la Draw(...) aggiungendoci: Draw(.... , int centroX, int centroY)poi questo comporta che dovrai andare in MAP ed aggiungerle anche li. Ora hai di nuovo in draw le 2 coordinate di centro del PG (che sostituiscono StartX e Y)Infine in Game1 => Draw, nel ciclo Foreach che parsa tutte le classi con interfaccia IGraph aggiungi dopo il .DRAW(spriteBatch, MioPG.X, MioPG.Y); dove MioPG.X e .Y sono le variabili che hai creato nel PGClass.quando implementerai il movimento, il PG cambierà questi valori ed avrai lo spostamento in mappa
* PG 
    1) OK. sistemare gli spostamenti come indicato prima
    2) piazzare bene il pupino
        1. ricavare il punto centrale della tile in cui disegnare (qualsiasi tile nella mappa, non solo quella centrale perché i mostri attorno devono camminare) per cui data una coordinata X1, Y1 di una mappa disegnata sul centro CentroX, CentroY tu devi avere il punto centrale della tile indicataDa:Federico Bastianelli
        2. i piedi devono partire dal punto centrale ovvero la grafica sale in altezza e non scende come si disegna di solito. Di solito tu dai una coordinata x,y ed il disegno, da quella coordinata va a destra ed in basso. Qua no
        3. i piedi, nella PNG, non sono al valore height ma poco più su per cui devi conoscere quale è il punto corretto (in ultima ha il valore da sottrarre, tipo -10, - 12 ecc.) per cui tu sai che il punto dei piedi è Width/2 , Height - 12 (riferiti alla grafica del pupino) ed allora da questi valori devi ricavarti il punto X e Y di inizio disegno
        4. se è difficile piazzarlo correttamente (non ricordo come l'ho fatto... mi misi a farlo a gennaio/febbraio) con Photoshop si può ricavare la differenza per il valore dei piedi ovvero la differenza per la Height. Questa info dovrebbe essere sempre la stessa per ogni insieme di animazioni. Si può perfino fare un file di testo da leggere per centrare le animazioni
    3) mettere su il barbaro
#Appunti
* variabile => è una variabile della funzione, inizializzata e morta all'interno della funzione
* _variabile => è una variabile privata della classe che puoi usare in tutte le funzioni
* Variabile => è una variabile pubblica o protetta della classe a cui puoi accedere dall'interno o dall'esterno
