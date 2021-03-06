﻿app = new Vue({
    el: '#app',
    data: {
        editing: false,
        loading: false,
        objectIndex: 0,
        trailerModel: {
            id: 0,
            vin: "",
            year: "",
            make: "",
            model: "",
            class: "",
            bodyType: "",
            lenght: "",
            description: "",
            trailerPlate: "",
            trailerNumber: "",
            titleNumber: "",
            titleState: "",
            titleIssueDate: "",
            purchasePrice: "",
            purchaseDate: "",
            status: ""
        },
        trailers: []
    },
    mounted() {
        this.getTrailers();
    },
    methods: {
        getTrailer(id) {
            this.loading = true;
            axios.get('/Admin/trailers/' + id)
                .then(res => {
                    console.log(res);
                    var trailer = res.data;
                    this.trailerModel = {
                        id: trailer.id,
                        vin: trailer.vin,
                        year: trailer.year,
                        make: trailer.make,
                        model: trailer.model,
                        class: trailer.class,
                        bodyType: trailer.bodyType,
                        lenght: trailer.lenght,
                        description: trailer.description,
                        trailerPlate: trailer.trailerPlate,
                        trailerNumber: trailer.trailerNumber,
                        titleNumber: trailer.titleNumber,
                        titleState: trailer.titleState,
                        titleIssueDate: trailer.titleIssueDate,
                        purchasePrice: trailer.purchasePrice,
                        purchaseDate: trailer.purchaseDate,
                        status: trailer.status
                    };
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        getTrailers() {
            this.loading = true;
            axios.get('/Admin/trailers')
                .then(res => {
                    console.log(res);
                    this.trailers = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        createTrailer() {
            this.loading = true;
            axios.post('/Admin/trailers', this.trailerModel)
                .then(res => {
                    console.log(res.data);
                    this.trailers.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        updateTrailer() {
            this.loading = true;
            axios.put('/Admin/trailers', this.trailerModel)
                .then(res => {
                    console.log(res.data);
                    this.trailers.splice(this.objectIndex, 1, res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                    this.editing = false;
                });
        },
        deleteTrailer(id, index) {
            this.loading = true;
            axios.delete('/Admin/trailers/' + id)
                .then(res => {
                    console.log(res);
                    this.trailers.splice(index, 1);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        newTrailer() {
            this.editing = true;
            this.trailerModel.id = 0;
        },
        editTrailer(id, index) {
            this.objectIndex = index;
            this.getTrailer(id);
            this.editing = true;
        },
        cancel() {
            this.editing = false;
        }
    },
    computed: {
    }
});