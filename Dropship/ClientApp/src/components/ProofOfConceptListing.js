import React, { Component } from 'react';
import authService from './api-authorization/AuthorizeService'
export class ProofOfConceptListing extends Component {


    async getListing() {
        const authToken = await authService.getAccessToken();
        const response = await fetch('listing', { headers: )
    }
}
