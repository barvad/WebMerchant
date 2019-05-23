import React, { Component } from 'react';
import './DataTable.css';

export class DataTable extends Component {


    constructor(props) {
        super(props);
        this.state = {
            pageLen: (props.pageLen * 1) || 10,
            count: 0,
            page: props.page || 1,
            url: props.url,
            data: []
        };
        this.objectConverter = props.objectConverter || (o => o);
        this.loadData();
    }

     loadData(page) {
         var body = { ...this.state };
         body.page = page || body.page;
        body.data = undefined;
        fetch(this.state.url,
            {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body:  JSON.stringify(body)  
            })
            .then(response => response.json())
            .then(data => {
                var state = { ...this.state};
                state.data = data.data;
                state.count = data.count;
                state.page = page || state.page;
                this.setState(state);
            });
    }

    

     getPages() {
        var pages = [];
        var pagesCount = Math.ceil(this.state.count / this.state.pageLen);
        for (var i = 1; i <= pagesCount; i++) {
            pages.push(i);
        }
         return pages.map(p => <a className={p===this.state.page ? 'pagerItemSelected': 'pagerItem'} onClick={() => this.loadData(p)}>{p}</a>);
}


     render() {
         return <div className="dataTable">
             <div className="content">
             <table >
            <tbody>
            { this.state.data.map((r, i) =>
        
            <tr>
            {
                            Object.values(this.objectConverter(r)).map(c => <td> {c} </td>)
                                
            } </tr>
        )
}

</tbody>
                 </table >
             </div>
    <div className="paginator">{this.getPages()}</div>
    </div>;
        }
}