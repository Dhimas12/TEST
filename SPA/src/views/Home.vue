<template>
  <div class="w-full flex justify-center">
<input placeholder="Ingrese el pokemon" type="text" 
    class="mt-10 p-2 border-blue-500 border-2" v-model="text" />

</div>

  <div class="mt-10 p-4 flex flex-wrap justify-center">

    
    <div
      class="ml-4 text-2xl text-blue-400"
      v-for="(pokemon, idx) in filteredPokemon"
      :key="idx"
    >
      <router-link :to="`/about/${urlIdLookup[pokemon.name]}`">
        {{ pokemon.name }}
      </router-link>
    </div>
  </div>
</template>

<script>
import { reactive, toRefs, computed } from "vue"; 

// @ is an alias to /src

export default {
  name: 'Home',
  
  setup() {
      const state = reactive({
      pokemons: [],
      filteredPokemon: computed(()=> updatePokemon()), 
      text: "",
      urlIdLookup: {}
      
    });

    fetch("http://localhost:51044/api/pokemon")
      .then((res) => res.json())
      .then((data) => {
        console.log(data);
        state.pokemons = data.results;
        state.urlIdLookup = data.results.reduce((acc, cur, idx)=> 
           acc = {...acc, [cur.name]:idx+1 }
        ,{})
        console.log('url',state.urlIdLookup+1)
        
      });

      function updatePokemon(){
        if(!state.text){
          return [] 
        }
        return state.pokemons.filter((pokemon)=> 
           pokemon.name.includes(state.text)
        )
      }

    

    return { ...toRefs(state) };
  }
  }

</script>
