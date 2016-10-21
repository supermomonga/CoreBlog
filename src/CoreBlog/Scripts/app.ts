declare var require: any

import * as Vue from 'vue'
import * as marked from 'marked'
marked.setOptions({
  renderer: new marked.Renderer(),
  gfm: true,
  tables: true,
  breaks: false,
  pedantic: false,
  sanitize: false,
  smartLists: true,
  smartypants: false
});

new Vue({
    el: "#mdeditor",
    data: {
        markdownArticle: ''
    },
    computed: {
        compiledArticle(): string {
            return marked(this.markdownArticle)
        }
    }
})
