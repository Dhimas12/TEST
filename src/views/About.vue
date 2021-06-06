<template>
  <div class="about">
    <div
      v-if="pokemon"
      className="w-3/12 m-auto bg-purple-100 mt-4 shadow-2xl flex justify-center flex-col items-center"
    >
      <h3 className="text-2xl text-green-900 uppercase">{{ pokemon.name }}</h3>
      <div class="flex justify-center">
        <img className="w-48" :src="pokemon.sprites.front_shiny" alt="" />
        <img className="w-48" :src="pokemon.sprites.back_shiny" alt="" />  
      </div> 
      
      <h3  class="text-yellow-400">Movimiento</h3>
      <div>
        <h5 class="text-blue-900">{{pokemon.moves[0].move.name}}</h5>
      </div> 
      <h3  class="text-yellow-400">Altura</h3>
      <div>
        <h5 class="text-blue-900">{{pokemon.height}}</h5>
      </div> 
       <h3  class="text-yellow-400">Experiencia</h3>
      <div>
        <h5 class="text-blue-900">{{pokemon.base_experience}}</h5>
      </div>  
      <input id="test-btn" type="button" v-on:click="descargarDetalle(pokemon.name, pokemon.base_experience, pokemon.height ,pokemon.moves[0].move.name)" value="Descargar Detalles">


      
       
    </div>
  </div>
</template>

<script>
import { reactive, toRefs } from "vue";
import { useRoute } from "vue-router"; 



export default { 
  
  setup() {
    const route = useRoute();

    const pokemon = reactive({
      pokemon: null 
    });
    fetch(`http://localhost:51044/api/pokemon/${route.params.slug}/`)
      .then((res) => res.json())
      .then((data) => {
        pokemon.pokemon = data;
        console.log(data);
      }); 

      

      
    return { ...toRefs(pokemon) }; 

  }, 

  methods:{
    descargarDetalle(nombre,exp, Altura,Peso){ 
        var contenido = `${nombre},${exp}, ${Altura},${Peso} `;
          window.open(`http://localhost:51044/api/pokemon/api/Download/${contenido}`);
          console.log(`Se ha descargado/${contenido}`);
          
        }
  },



} 

    

</script> 
<style> 

#test-btn {
   background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: px 15px;
  text-align: right ;
  text-decoration: none;
  display: inline-balock;
  font-size: 15px; 
  cursor: pointer;
  display: inline-block;
  position: relative;
  transition: 0.5s;
} 


#test-btn span::after{
  content: '\00bb';
  position: absolute;
  opacity: 0;
  top: 0;
  right: -20px;
  transition: 0.5s;
}

#test-btn:hover span{
    padding-right: 25px;

}  
#test-btn:hover span::after{
   opacity: 1;
  right: 0;
}

</style>
