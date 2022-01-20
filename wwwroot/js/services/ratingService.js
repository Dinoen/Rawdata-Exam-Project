define([], () => {

    let getRatings = (callback) => {
        let param = {
            headers: {
                "Content-Type": "application/json",
                'Authorization': 'Bearer ' + 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjkiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM4ODczMjA0LCJleHAiOjE2Mzg4NzUwMDQsImlhdCI6MTYzODg3MzIwNH0.NSZ2J3wA72VV6T-RnBCSodqmuD0Illul-FBc-ckLzbc'
            }
        }
        fetch("api/Bookmark/TitleBookmark/1", param)
            .then(response => response.json())
            .then(json => console.log(json));
    };

    return {
        getBookmarks
    }
});