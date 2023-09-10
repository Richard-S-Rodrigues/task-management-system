import './index.css'
import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from './router'
import { library } from '@fortawesome/fontawesome-svg-core'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import { faPenToSquare, faTrash, faRightLong, faXmark } from '@fortawesome/free-solid-svg-icons'

library.add(faPenToSquare, faTrash, faRightLong, faXmark)

const pinia = createPinia()
const app = createApp(App).component('font-awesome-icon', FontAwesomeIcon)

app.use(router)
app.use(pinia)
app.mount('#app')
