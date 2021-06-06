<template>
    <table>
        <tr>
            <td> Nombre </td>
            <td> Habilidad</td>
            <td> Movimiento </td>
            <td> Altura </td>
        </tr>
        <tr v-for ="item in list" >
            <td> {{item.name}}</td>
            <td> {{item.height}}</td>
            <td> Movimiento </td>
            <td> Altura </td>
        </tr>
    </table>
</template> 
<script>
    import Vue from 'vue';
    import axios from 'axios'
    import VueAxios from 'vue-axios'
    Vue.use(VueAxios, axios) 
    data: {
        nombre: ''
    }
    export default {
        name: "Pokemon" 
        mounted() {
            Vue.axios.get('https://pokeapi.co/api/v2/pokemon/' + this.nombre)
                .then((resp) => {
                    this.list = resp.data.data;

                    console.warn(resp.data.data)

        })
    }
</script>