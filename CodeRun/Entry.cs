using System;

namespace CodeRun {
    class Entry { //Un arrivante
        private String pettorale;
        private String ora; //Ora di arrivo
        private String tempo; //Tempo impiegato
        private int posizione;

        public Entry(String pettorale, int posizione, String ora, String tempo) {
            this.setPettorale(pettorale);
            this.setPosizione(posizione);
            this.setOra(ora);
            this.setTempo(tempo);
        }
        
        public String getPettorale() {
            return this.pettorale;
        }

        public void setPettorale(String pettorale) {
            this.pettorale = pettorale;
        }

        public int getPosizione() {
            return this.posizione;
        }

        public void setPosizione(int posizione) {
            this.posizione = posizione;
        }

        public String getOra() {
            return this.ora;
        }

        public void setOra(String ora) {
            this.ora = ora;
        }

        public String getTempo() {
            return this.tempo;
        }

        public void setTempo(String tempo){
            this.tempo = tempo;
        }
    }
}
